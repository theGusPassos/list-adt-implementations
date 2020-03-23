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
            
            [TestFixture]
            public class AddSameAsRoot
            {
                private BinarySearchTree<int> binarySearchTree;
                private const int rootValue = 1;

                [OneTimeSetUp]
                public void AddToEmptyList()
                {
                    binarySearchTree = new BinarySearchTree<int>();
                    binarySearchTree.Add(rootValue);
                    binarySearchTree.Add(rootValue);
                }

                [Test]
                public void ShouldNotChangeRoot()
                    => binarySearchTree.Root.Value.Should().Be(rootValue);

                [Test]
                public void RootShouldStillBeLeaf()
                    => binarySearchTree.Root.IsLeaf().Should().BeTrue();
            }

            [TestFixture]
            public class AddGreaterThanRoot
            {
                private BinarySearchTree<int> binarySearchTree;
                private const int rootValue = 1;
                private const int valueAdded = 2;

                [OneTimeSetUp]
                public void AddGreaterValue()
                {
                    binarySearchTree = new BinarySearchTree<int>();
                    binarySearchTree.Add(rootValue);
                    binarySearchTree.Add(valueAdded);
                }

                [Test]
                public void ShouldSetRightToRoot()
                    => binarySearchTree.Root.Right.Value.Should().Be(valueAdded);

                [Test]
                public void RootShouldBeOriginalValue()
                    => binarySearchTree.Root.Value.Should().Be(rootValue);
            }

            [TestFixture]
            public class AddLessThanRoot
            {
                private BinarySearchTree<int> binarySearchTree;
                private const int rootValue = 1;
                private const int valueAdded = -1;

                [OneTimeSetUp]
                public void AddLessThanRott()
                {
                    binarySearchTree = new BinarySearchTree<int>();
                    binarySearchTree.Add(rootValue);
                    binarySearchTree.Add(valueAdded);
                }

                [Test]
                public void ShouldSetLeftToRoot()
                    => binarySearchTree.Root.Left.Value.Should().Be(valueAdded);

                [Test]
                public void RootShouldBeOriginalValue()
                    => binarySearchTree.Root.Value.Should().Be(rootValue);
            }
        }
    }
}
