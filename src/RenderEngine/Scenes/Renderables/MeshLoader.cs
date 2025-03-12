
using OpenTK.Mathematics;



namespace RenderEngine.Scenes.Renderables;



internal static class MeshLoader
{
    /// <summary>
    /// Very basic Wavefront .obj file parser
    /// </summary>
    public static IMesh LoadMesh(string filePath)
    {
        List<Vector3> vertices = [];
        List<Vector2> uvs = [];
        List<uint> indices = [];

        foreach (string line in File.ReadLines(filePath))
        {
            if (line.Length < 2) continue;

            switch (line.AsSpan(0..2))
            {
                case "v ":
                    AddVertex(line);
                    break;

                case "vt":
                    AddUV(line);
                    break;
                
                case "f ":
                    AddFace(line);
                    break;

                default:
                    break;
            }
        }


        void AddVertex(string line)
        {
            List<float> components = line.Split(' ')[1..3].Select(float.Parse).ToList();

            vertices.Add(new(components[0], components[1], components[2]));
        }


        void AddUV(string line)
        {
            List<float> components = line.Split(' ')[1..2].Select(float.Parse).ToList();

            uvs.Add(new(components[0], components[1]));
        }


        void AddFace(string line)
        {
            List<uint> indices = line.Split(' ')[1..].Select(uint.Parse).ToList();

            uint baseIndex = indices[0];

            for (int i = 1; i < indices.Count; i += 2)
            {
                indices.Add(baseIndex);
                indices.Add(indices[i]);
                indices.Add(indices[i + 1]);
            }
        }



        return new Mesh(vertices, uvs, indices);
    }
}
