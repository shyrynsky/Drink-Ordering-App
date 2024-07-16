using Xunit;
using Moq;
using lab2;
namespace lab3.Tests;

public class FormTest
{
    [Fact]
    public void AddingTest()
    {
        var mock = new Mock<ILogger>();
        var form = new Form1(mock.Object);
        form.Form1_Load(null!, null!);
        form.createButton_Click(null!, null!);
        Assert.Single(form.DrinkList);
        Assert.Equal("чай()", form.DrinkList[0].Name);
    }
}