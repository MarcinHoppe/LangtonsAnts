using System;
using Xunit;

namespace MarcinHoppe.LangtonsAnts.Tests
{
    public class LatticeTests
    {
        Lattice lattice = new Lattice();

        [Fact]
        public void LatticeOriginIsInitiallyWhite()
        {
            Assert.Equal(Colors.White, lattice.ColorAt(0, 0));
        }
    }
}
