using NUnit.Framework;
using TestNinja.Fundamentals;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Push_ArgIsNull_ThrowArgNullException()
        {
            var stack = new Stack2<string>();

            Assert.That(() => stack.Push(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Push_ValidArg_AddObjectToStack()
        {
            var stack = new Stack2<string>();

            stack.Push("a");

            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            var stack = new Stack2<string>();

            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Count_OneObjectPushedToStack_ReturnOne()
        {
            var stack = new Stack2<string>();

            stack.Push("a");

            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Stack2<string>();

            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackWithAFewObjects_ReturnObjectOnTheTop()
        {
            //Arrange
            var stack = new Stack2<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            //Act
            var result = stack.Pop();

            //Assert
            Assert.That(result, Is.EqualTo("c"));
            //pre uistenie sa ze test funguje spravne je treba po jeho napisani a uspesnom zbehnuti zmenit business logiku s predpokladom ze by mal test zlyhat pre overenie
        }

        [Test]
        public void Pop_StackWithAFewObjects_RemoveObjectFromStack()
        {
            //Arrange
            var stack = new Stack2<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            //Act
            var result = stack.Pop();

            //Assert
            Assert.That(stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Stack2<string>();

            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackWithObjects_ReturnObjectOnTopOfTheStack()
        {
            //Arrange
            var stack = new Stack2<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            //Act
            var result = stack.Peek();

            //Assert
            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Peek_StackWithObjects_DoesNotRemoveObjectOnTopOfTheStack()
        {
            //Arrange
            var stack = new Stack2<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            //Act
            var result = stack.Peek();

            //Assert
            Assert.That(stack.Count, Is.EqualTo(3));
        }
    }
}
