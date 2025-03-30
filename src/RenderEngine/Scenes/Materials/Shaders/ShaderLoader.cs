
using OpenTK.Graphics.OpenGL4;



namespace RenderEngine.Scenes.Materials.Shaders;



public class ShaderLoader : IShaderLoader
{
    public IShaderProgram LoadShader(string shaderPath)
    {
        int shaderID = GL.CreateProgram();

        string vertexShaderPath = $"{shaderPath}.vert";
        string fragmentShaderPath = $"{shaderPath}.frag";

        int vertexShader = CompileShader(ShaderType.VertexShader, LoadShaderSource(vertexShaderPath));
        int fragmentShader = CompileShader(ShaderType.FragmentShader, LoadShaderSource(fragmentShaderPath));

        GL.AttachShader(shaderID, vertexShader);
        GL.AttachShader(shaderID, fragmentShader);

        GL.LinkProgram(shaderID);

        GL.GetProgram(shaderID, GetProgramParameterName.LinkStatus, out int success);
        if (success == 0)
        {
            string infoLog = GL.GetProgramInfoLog(shaderID);
            GL.DeleteProgram(shaderID);
            throw new Exception($"Shader program linking failed\nFragment shader path: {fragmentShaderPath}, vertex shader path: {vertexShaderPath}\n{infoLog}\n{LoadShaderSource(fragmentShaderPath)}");
        }

        GL.DeleteShader(vertexShader);
        GL.DeleteShader(fragmentShader);

        return new BasicMeshShader(shaderID, true);
    }



    private static int CompileShader(ShaderType type, string code)
    {
        int shader = GL.CreateShader(type);
        GL.ShaderSource(shader, code);
        GL.CompileShader(shader);

        GL.GetShader(shader, ShaderParameter.CompileStatus, out int success);
        if (success == 0)
        {
            string infoLog = GL.GetShaderInfoLog(shader);
            throw new Exception($"Shader {type} compilation failed!!\n{infoLog}");
        }

        return shader;
    }



    public static string LoadShaderSource(string filePath)
    {
        return File.ReadAllText(filePath);
    }
}