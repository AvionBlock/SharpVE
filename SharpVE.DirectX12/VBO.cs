using SharpVE.Core.Interfaces.Graphics;
using Silk.NET.Core.Native;
using Silk.NET.Direct3D12;

namespace SharpVE.DirectX12
{
    public class VBO : IVBO
    {
        ComPtr<ID3D12Resource> Data = default;
        protected readonly D3D12 GraphicsInstance;

        public VBO(D3D12 GraphicsInstance)
        {
            this.GraphicsInstance = GraphicsInstance;
        }
    }
}
