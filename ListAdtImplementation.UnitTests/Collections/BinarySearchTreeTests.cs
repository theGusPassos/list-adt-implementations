using FluentAssertions;
using ListAdtImplementation.Collections;
using NUnit.Framework;

namespace ListAdtImplementation.UnitTests.Collections
{
    [TestFixture]
    public class BinarySearchTreeTests 
    {
        [TestFixture]
        public class Adding
        {
            [TestFixture]
            public class AddInEmptyTree
            {
                private BinarySearchTree<int> binarySearchTree;
                private const int valueAdded = 1;

                [OneTimeSetUp]
                public void AddToEmptyList()
                {
                    binarySearchTree = new BinarySearchTree<int>();
                    binarySearchTree.Add(valueAdded);
                }

                [Test]
                public void ShouldSetAsRoot()
                    => binarySearchTree.Root.Value.Should().Be(valueAdded);

                [Test]
                public void RootShouldBeLeaf()
                    => binarySearchTree.Root.IsLeaf().Should().BeTrue();
            }
        }
    }
}
