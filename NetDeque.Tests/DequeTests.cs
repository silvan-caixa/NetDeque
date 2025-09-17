using FluentAssertions;

namespace NetDeque.Tests;

public class DequeTests
    {
    //1. Estado inicial
    [Fact]
    public void NewDeque_ShouldHaveCountZero()
        {
        //arrange
        var deque = new Deque<int>();
        //act
        var count = deque.Count;
        //assert
        // Assert.Equal(0, deque.Count);
        count.Should().Be(0);
        }

    [Fact]
    public void NewDeque_ShouldBeEmpty()
        {
        //arrange
        var deque = new Deque<int>();
        //act
        var isEmpty = deque.IsEmpty;
        //assert
        // Assert.True(deque.IsEmpty);
        isEmpty.Should().BeTrue();
        }

    //2. Inserções no início (AddBeg)
    [Fact]
    public void AddBeg_ShouldMakePeekBegReturnSameElement()
        {
        //arrange
        var deque = new Deque<int>();
        //act
        deque.AddBeg(42);
        //assert
        //Assert.Equal(42, deque.PeekBeg());
        deque.PeekBeg().Should().Be(42);
        }

    [Fact]
    public void AddBeg_MultipleInsertions_ShouldPreserveOrder()
        {
        //arrange
        var deque = new Deque<string>();
        //act
        deque.AddBeg("third");
        deque.AddBeg("second");
        deque.AddBeg("first");
        //assert
        //Assert.Equal("first", deque.PeekBeg());
        //Assert.Equal("first", deque.RemBeg());
        //Assert.Equal("second", deque.RemBeg());
        //Assert.Equal("third", deque.RemBeg());
        //Assert.True(deque.IsEmpty);
        deque.PeekBeg().Should().Be("first")
                        .And.NotBeNull();

        deque.RemBeg().Should().Be("first")
            .And.NotBeNull();

        deque.RemBeg().Should().Be("second")
            .And.NotBeNull();

        deque.RemBeg().Should().Be("third")
            .And.NotBeNull();

        deque.IsEmpty.Should().BeTrue()
            .And.Be(deque.Count == 0);

        }

    [Fact]
    public void AddEnd_ShouldReturnElementWithPeekEnd()
        {
        var deque = new Deque<int>();
        deque.AddEnd(100);
        Assert.Equal(100, deque.PeekEnd());
        }

    //Inserções no final (AddEnd)
    [Fact]
    public void AddEnd_MultipleElements_ShouldMaintainOrder()
        {
        //arrange
        var deque = new Deque<int>();
        //act
        deque.AddEnd(1);
        deque.AddEnd(2);
        deque.AddEnd(3);
        //assert
        //Assert.Equal(3, deque.PeekEnd());
        //Assert.Equal(1, deque.RemBeg());
        //Assert.Equal(2, deque.RemBeg());
        //Assert.Equal(3, deque.RemBeg());

        deque.PeekEnd().Should().Be(3);
        deque.RemBeg().Should().Be(1);
        deque.RemBeg().Should().Be(2);
        deque.RemBeg().Should().Be(3);
        deque.IsEmpty.Should().BeTrue();

        }

    [Fact]
    public void AddEnd_MultipleElements_ShouldMaintainCorrectOrder()
        {
        // Arrange
        var deque = new Deque<int>();

        // Act
        deque.AddEnd(1);
        deque.AddEnd(2);
        deque.AddEnd(3);

        // Assert

        //Assert.Equal(3, deque.PeekEnd());
        //Assert.Equal(1, deque.RemBeg());
        //Assert.Equal(2, deque.RemBeg());
        //Assert.Equal(3, deque.RemBeg());
        //Assert.True(deque.IsEmpty);

        deque.RemBeg().Should().Be(1);
        deque.RemBeg().Should().Be(2);
        deque.RemBeg().Should().Be(3);
        deque.IsEmpty.Should().BeTrue();
        }
    //4. Remoções no início (RemBeg)

    [Fact]
    public void RemBeg_FromEmptyDeque_ShouldThrowException_UsingAssert()
        {
        // Arrange
        var deque = new Deque<int>();

        // Act & Assert
        //Assert.Throws<InvalidOperationException>(() => deque.RemBeg());

        Action act = () => deque.RemBeg();
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("Deque is empty.");

        }
    [Fact]
    public void AddBeg_AndRemove_ShouldMaintainCorrectOrder_UsingAssert()
        {
        // Arrange
        var deque = new Deque<string>();

        // Act
        deque.AddBeg("third");
        deque.AddBeg("second");
        deque.AddBeg("first");

        // Assert
        //Assert.Equal("first", deque.RemBeg());
        //Assert.Equal("second", deque.RemBeg());
        //Assert.Equal("third", deque.RemBeg());
        //Assert.True(deque.IsEmpty);


        deque.RemBeg().Should().Be("first");
        deque.RemBeg().Should().Be("second");
        deque.RemBeg().Should().Be("third");

        }
    [Fact]
    public void RemovingElements_ShouldDecrementCount_UsingAssert()
        {
        // Arrange
        var deque = new Deque<int>();
        deque.AddEnd(10);
        deque.AddEnd(20);
        deque.AddEnd(30);

        // Act
        deque.RemBeg(); // Remove 10

        // Assert
        //Assert.Equal(2, deque.Count);

        //deque.RemEnd(); // Remove 30
        //Assert.Equal(1, deque.Count);

        //deque.RemBeg(); // Remove 20
        //Assert.Equal(0, deque.Count);


        deque.Count.Should().Be(2);

        deque.RemEnd(); // Remove 30
        deque.Count.Should().Be(1);

        deque.RemBeg(); // Remove 20
        deque.Count.Should().Be(0);

        }
    //5. Remoções no final (RemEnd)
    [Fact]
    public void RemEnd_FromEmptyDeque_ShouldThrowException_UsingAssert()
        {
        // Arrange
        var deque = new Deque<int>();

        // Act & Assert
        //Assert.Throws<InvalidOperationException>(() => deque.RemEnd());
        Action act = () => deque.RemEnd();
        act.Should().Throw<InvalidOperationException>()
               .WithMessage("Deque is empty.");
        }
    [Fact]
    public void AddEnd_AndRemove_ShouldMaintainCorrectOrder_UsingAssert()
        {
        // Arrange
        var deque = new Deque<string>();

        // Act
        deque.AddEnd("first");
        deque.AddEnd("second");
        deque.AddEnd("third");

        // Assert
        //Assert.Equal("first", deque.RemBeg());
        //Assert.Equal("second", deque.RemBeg());
        //Assert.Equal("third", deque.RemBeg());
        //Assert.True(deque.IsEmpty);


        deque.RemBeg().Should().Be("first");
        deque.RemBeg().Should().Be("second");
        deque.RemBeg().Should().Be("third");
        deque.IsEmpty.Should().BeTrue();
        }
    [Fact]
    public void Count_ShouldDecrement_AfterRemovals_UsingAssert()
        {
        // Arrange
        var deque = new Deque<int>();
        deque.AddBeg(1);
        deque.AddBeg(2);
        deque.AddBeg(3);

        // Act & Assert
        //Assert.Equal(3, deque.Count);

        //deque.RemBeg();
        //Assert.Equal(2, deque.Count);

        //deque.RemEnd();
        //Assert.Equal(1, deque.Count);

        //deque.RemBeg();
        //Assert.Equal(0, deque.Count);


        deque.Count.Should().Be(3);

        deque.RemBeg();
        deque.Count.Should().Be(2);

        deque.RemEnd();
        deque.Count.Should().Be(1);

        deque.RemBeg();
        deque.Count.Should().Be(0);


        }
    //6. Espiadas (PeekBeg e PeekEnd)
    [Fact]
    public void PeekBeg_FromEmptyDeque_ShouldThrowException_UsingAssert()
        {
        // Arrange
        var deque = new Deque<int>();

        // Act & Assert
        //Assert.Throws<InvalidOperationException>(() => deque.PeekBeg());
        Action act = () => deque.PeekBeg();
        act.Should().Throw<InvalidOperationException>()
                .WithMessage("Deque is empty.");

        }
    [Fact]
    public void PeekEnd_FromEmptyDeque_ShouldThrowException_UsingFluentAssertions()
        {
        // Arrange
        var deque = new Deque<int>();

        // Act
        Action act = () => deque.PeekEnd();

        // Assert
        //Assert.Throws<InvalidOperationException>(() => deque.PeekEnd());
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("Deque is empty.");
        }




    }
