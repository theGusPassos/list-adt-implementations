using FluentAssertions;
using ListAdtImplementation.Collections;
using NUnit.Framework;

namespace ListAdtImplementation.UnitTests.Collections
{
    public class BinarySearchTreeAvlTests
    {
        [TestFixture]
        public class Adding
        {
            [TestFixture]
            public class AddInEmptyTree
            {
                private BinarySearchTreeAvl<int> binarySearchTree;
                private const int valueAdded = 1;

                [OneTimeSetUp]
                public void AddToEmptyList()
                {
                    binarySearchTree = new BinarySearchTreeAvl<int>();
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
                private BinarySearchTreeAvl<int> binarySearchTree;
                private const int rootValue = 1;

                [OneTimeSetUp]
                public void AddToEmptyList()
                {
                    binarySearchTree = new BinarySearchTreeAvl<int>();
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
                private BinarySearchTreeAvl<int> binarySearchTree;
                private const int rootValue = 1;
                private const int valueAdded = 2;

                [OneTimeSetUp]
                public void AddGreaterValue()
                {
                    binarySearchTree = new BinarySearchTreeAvl<int>();
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
                private BinarySearchTreeAvl<int> binarySearchTree;
                private const int rootValue = 1;
                private const int valueAdded = -1;

                [OneTimeSetUp]
                public void AddLessThanRott()
                {
                    binarySearchTree = new BinarySearchTreeAvl<int>();
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

        [TestFixture]
        public class Deleting
        {
            [Test]
            public void ShouldDoNothingInEmptyTree()
            {
                var binaryTree = new BinarySearchTreeAvl<int>();
                binaryTree.Remove(1);
                binaryTree.Root.Should().BeNull();
            }

            [Test]
            public void ShouldDeleteRootWhenIsRoot()
            {
                var binaryTree = new BinarySearchTreeAvl<int>();
                binaryTree.Add(1);
                binaryTree.Remove(1);
                binaryTree.Root.Should().BeNull();
            }

            [Test]
            public void ShouldRemoveNodeIfIsLeaf()
            {
                var binaryTree = new BinarySearchTreeAvl<int>();
                binaryTree.Add(1);
                binaryTree.Add(2);
                binaryTree.Remove(2);
                binaryTree.Root.IsLeaf().Should().BeTrue();
            }

            [TestFixture]
            public class DeleteWithOneChild
            {
                private BinarySearchTreeAvl<int> binaryTree;

                [OneTimeSetUp]
                public void CreateTree()
                {
                    binaryTree = new BinarySearchTreeAvl<int>();
                    binaryTree.Add(1);
                    binaryTree.Add(2);
                    binaryTree.Add(3);
                    binaryTree.Remove(2);
                }

                [Test]
                public void RemovedShouldNotExistInTree()
                    => binaryTree.Contains(2).Should().BeFalse();

                [Test]
                public void HeadRightChildShouldBeDeletedChild()
                    => binaryTree.Root.Right.Value.Should().Be(3);
            }

            [TestFixture]
            public class DeleteWithTwoChildren
            {
                private BinarySearchTree<int> binaryTree;

                [OneTimeSetUp]
                public void CreateTree()
                {
                    binaryTree = new BinarySearchTree<int>();
                    binaryTree.Add(1);
                    binaryTree.Add(3);
                    // 3 children
                    binaryTree.Add(2);
                    binaryTree.Add(4);
                    binaryTree.Remove(3);
                }

                [Test]
                public void DeletedShouldNotExist()
                    => binaryTree.Contains(3).Should().BeFalse();

                [Test]
                public void DeletedShouldBeReplacedByMinRightChild()
                    => binaryTree.Root.Right.Value.Should().Be(4);

                [Test]
                public void NewDeletedShouldHaveChildFromRemoved()
                    => binaryTree.Root.Right.Left.Value.Should().Be(2);
            }
        }
    
        [TestFixture]
        public class HeightSetting
        {
            [Test]
            public void RootShouldHaveHeightOneAsLeaf()
            {
                var binarySearchTree = new BinarySearchTreeAvl<int>();
                binarySearchTree.Add(1);
                binarySearchTree.Root.Height.Should().Be(1);
            }

            [Test]
            public void RootShouldHaveHeight1WithChildren()
            {
                var binarySearchTree = new BinarySearchTreeAvl<int>();
                binarySearchTree.Add(1);
                binarySearchTree.Add(2);
                binarySearchTree.Root.Height.Should().Be(2);
            }

            [Test]
            public void RootShouldHaveHeight1With2Children()
            {
                var binarySearchTree = new BinarySearchTreeAvl<int>();
                binarySearchTree.Add(1);
                binarySearchTree.Add(2);
                binarySearchTree.Add(-1);
                binarySearchTree.Root.Height.Should().Be(2);
            }

            [Test]
            public void RootShouldHaveHeight2With1ChildrenWithChild()
            {
                var binarySearchTree = new BinarySearchTreeAvl<int>();
                binarySearchTree.Add(1);
                binarySearchTree.Add(2);
                binarySearchTree.Add(3);
                binarySearchTree.Root.Height.Should().Be(3);
            }
        }
    
        [TestFixture]
        public class SingleRotation
        {
            [TestFixture]
            public class RootSingleRightRotation
            {
                private BinarySearchTreeAvl<int> tree;

                [OneTimeSetUp]
                public void TestSingleLeftRotationInRoot()
                {
                    tree = new BinarySearchTreeAvl<int>();
                    tree.Add(1, 2, 3);
                }

                [Test]
                public void RootShouldBe2() 
                    => tree.Root.Value.Should().Be(2);

                [Test]
                public void RootLeftShouldBe1() 
                    => tree.Root.Left.Value.Should().Be(1);
                
                [Test]
                public void RootRightShouldBe3() 
                    => tree.Root.Right.Value.Should().Be(3);
            }
        }
    }
}
