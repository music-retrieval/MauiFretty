using System.Runtime.InteropServices;

namespace Fretty.Processing;

public class Essentia
{
    [DllImport("libFrettysEssentia.so", CallingConvention = CallingConvention.Cdecl)]
    private static extern string test();
    
    [DllImport("libFrettysEssentia.so", CallingConvention = CallingConvention.Cdecl)]
    private static extern List<string> compute_chords(string filename);
    
    // Declare the external functions from the C++ DLL
    [DllImport("libFrettysEssentia.so", CallingConvention = CallingConvention.Cdecl)]
    private static extern void essentia_init();

    [DllImport("libFrettysEssentia.so", CallingConvention = CallingConvention.Cdecl)]
    private static extern void essentia_shutdown();

    [DllImport("libFrettysEssentia.so", CallingConvention = CallingConvention.Cdecl)]
    private static extern void essentia_load_audio(string audioFilename, double[] audioBuffer, UIntPtr length);

    public static void testMe()
    {
        Console.WriteLine(test());
    }
    
    public static List<string> getChords(string filename)
    {
        List<string> from_c_plus = compute_chords(filename);

        return from_c_plus;
    }

    public static double[] getAudio()
    {
        double[] buffer = new double[100];
        
        // Call the C++ function from C#
        essentia_init();
        // essentia_load_audio("/Run/example_audio_file.mp3", buffer, 100);
        essentia_shutdown();

        return buffer;
    }
}