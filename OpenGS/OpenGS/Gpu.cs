using OpenTK.Graphics.OpenGL;


namespace OpenGS
{
    public class Gpu
    {
        public static int GetMaxTextureSize()
        {
            int[] maxTextureSize = new int[2];
            GL.GetInteger(GetPName.MaxTextureSize, maxTextureSize);
            return maxTextureSize[0];
        }
    }
}
