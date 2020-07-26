using System.Collections.Generic;

namespace LangtonsAnt
{
    public interface IRender
    {
        void Render(IEnumerable<ChangeEvent> events);
    }
}