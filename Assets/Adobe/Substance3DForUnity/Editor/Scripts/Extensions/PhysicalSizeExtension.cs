using System;
using System.Runtime.InteropServices;
using UnityEngine;
using Adobe.Substance;

namespace Adobe.SubstanceEditor
{
    internal static class PhysicalSizeExtension
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct NativePhysicalSize
        {
            public float X;
            public float Y;
            public float Z;
        }

        [DllImport("sbsario_ext_physical_size")]
        private static extern uint sbsario_sbsar_get_physical_size(IntPtr sbsar_handle, IntPtr graph, out NativePhysicalSize physicaSize);

        /// <summary>
        /// Graph physical size property.
        /// </summary>
        /// <returns></returns>
        public static Vector3 GetPhysicalSize(this SubstanceNativeGraph nativeGraph)
        {
            sbsario_sbsar_get_physical_size(nativeGraph.GetNativeHandle(), (IntPtr)nativeGraph.GetFileGraphID(), out NativePhysicalSize nativePhysicalSize);
            return new Vector3(nativePhysicalSize.X, nativePhysicalSize.Y, nativePhysicalSize.Z);
        }

        public static bool IsSupported()
        {
            return PluginPipelines.IsHDRP();
        }
    }
}