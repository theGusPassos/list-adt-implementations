using Bogus;
using FluentAssertions;
using ListAdtImplementation.Collections;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

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

            [TestFixture]
            public class AddMultiple
            {
                private BinarySearchTree<int> binarySearchTree;
                private const int rootValue = 5;

                [OneTimeSetUp]
                public void AddMultipleValues()
                {
                    binarySearchTree = new BinarySearchTree<int>();
                    binarySearchTree.Add(rootValue);
                    binarySearchTree.Add(rootValue - 1);
                    binarySearchTree.Add(rootValue - 2);
                    binarySearchTree.Add(rootValue + 1);
                    binarySearchTree.Add(rootValue + 2);
                }

                [Test]
                public void RootShouldBeRootValue()
                    => binarySearchTree.Root.Value.Should().Be(rootValue);

                [Test]
                public void RootLeftShouldBeRootMinusOne()
                    => binarySearchTree.Root.Left.Value.Should().Be(rootValue - 1);

                [Test]
                public void RootLeftLeftShouldBeRootMinusTwo()
                    => binarySearchTree.Root.Left.Left.Value.Should().Be(rootValue - 2);

                [Test]
                public void RootRightShouldBeRootPlusOne()
                    => binarySearchTree.Root.Right.Value.Should().Be(rootValue + 1);

                [Test]
                public void RootRightRightShouldBeRootPlusTwo()
                    => binarySearchTree.Root.Right.Right.Value.Should().Be(rootValue + 2);
            }
        }

        [TestFixture]
        public class Searching
        {
            [Test]
            public void ShouldReturnFalseInEmptyTree()
            {
                var binarySearchTree = new BinarySearchTree<int>();
                binarySearchTree.Contains(1).Should().BeFalse();
            }

            [Test]
            public void ShouldReturnTrueIfIsRoot()
            {
                var binarySearchTree = new BinarySearchTree<int>();
                binarySearchTree.Add(1);
                binarySearchTree.Contains(1).Should().BeTrue();
            }

            [Test]
            public void ShouldReturnFalseIfNotFound()
            {
                var binarySearchTree = new BinarySearchTree<int>();
                var faker = new Faker();

                for (int i = 0; i < 20; i++)
                {
                    binarySearchTree.Add(faker.Random.Int(0, int.MaxValue));
                }

                binarySearchTree.Contains(int.MinValue).Should().BeFalse();
            }

            [Test]
            public void ShouldReturnTrueIfFound()
            {
                var binarySearchTree = new BinarySearchTree<int>();
                var faker = new Faker();

                for (int i = 0; i < 20; i++)
                {
                    binarySearchTree.Add(faker.Random.Int(0, int.MaxValue));
                }

                binarySearchTree.Add(1);
                binarySearchTree.Contains(1).Should().BeTrue();
            }
        }
    
        [TestFixture]
        public class Deleting
        {
            [Test]
            public void ShouldDoNothingInEmptyTree()
            {
                var binaryTree = new BinarySearchTree<int>();
                binaryTree.Remove(1);
                binaryTree.Root.Should().BeNull();
            }

            [Test]
            public void ShouldDeleteRootWhenIsRoot()
            {
                var binaryTree = new BinarySearchTree<int>();
                binaryTree.Add(1);
                binaryTree.Remove(1);
                binaryTree.Root.Should().BeNull();
            }

            [Test]
            public void ShouldRemoveNodeIfIsLeaf()
            {
                var binaryTree = new BinarySearchTree<int>();
                binaryTree.Add(1);
                binaryTree.Add(2);
                binaryTree.Remove(2);
                binaryTree.Root.IsLeaf().Should().BeTrue();
            }

            [TestFixture]
            public class DeleteWithOneChild
            {
                private BinarySearchTree<int> binaryTree;

                [OneTimeSetUp]
                public void CreateTree()
                {
                    binaryTree = new BinarySearchTree<int>();
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
        public class InorderTraversal
        {
            private IList<int> expectedOrder;
            private IList<int> traverseResult;

            [OneTimeSetUp]
            public void CreateAndTraverse()
            {
                expectedOrder = new List<int> { -4, -3, -1, 1, 2 };
                var binaryTree = new BinarySearchTree<int>();
                binaryTree.Add(1, 2, -3, -1, -4);

                traverseResult = new List<int>();
                binaryTree.InOrderTraversal(x => traverseResult.Add(x));
            }

            [Test]
            public void ShouldHaveExpectedOrder()
                => traverseResult.Should().ContainInOrder(expectedOrder);
        }

        [TestFixture]
        public class PreorderTraversal
        {
            private IList<int> expectedOrder;
            private IList<int> traverseResult;

            [OneTimeSetUp]
            public void CreateAndTraverse()
            {
                expectedOrder = new List<int> { 1, -3, -4, -1, 2 };
                var binaryTree = new BinarySearchTree<int>();
                binaryTree.Add(1, 2, -3, -1, -4);

                traverseResult = new List<int>();
                binaryTree.PreorderTraversal(x => traverseResult.Add(x));
            }

            [Test]
            public void ShouldHaveExpectedOrder()
                => traverseResult.Should().ContainInOrder(expectedOrder);
        }
        
        [TestFixture]
        public class PostorderTraversal
        {
            private IList<int> expectedOrder;
            private IList<int> traverseResult;

            [OneTimeSetUp]
            public void CreateAndTraverse()
            {
                expectedOrder = new List<int> { -4, -1, -3, 2, 1 };
                var binaryTree = new BinarySearchTree<int>();
                binaryTree.Add(1, 2, -3, -1, -4);

                traverseResult = new List<int>();
                binaryTree.PostorderTraversal(x => traverseResult.Add(x));
            }

            [Test]
            public void ShouldHaveExpectedOrder()
                => traverseResult.Should().ContainInOrder(expectedOrder);
        }
    }
}
