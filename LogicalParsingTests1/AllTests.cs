using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicalParsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using LogicalParsing;
namespace LogicalParsing.Tests
{
    [TestClass()]
    public class AllTests
    {

        [TestMethod()]
        public void FillTable_NonBooleanExpression_ReturnsNull()
        {
            // Arrange
            var expression = new Expression("A + B");

            // Act
            var truthTable = TruthTable.FillTable(expression);

            // Assert
            Assert.IsNull(truthTable);
        }

        [TestMethod()]
        public void FillTable_EmptyExpression_ReturnsNull()
        {
            // Arrange
            var expression = new Expression("");

            // Act
            var truthTable = TruthTable.FillTable(expression);

            // Assert
            Assert.IsNull(truthTable);
        }




        [TestMethod()]
        public void FillTable_InvalidExpressionWithVariables_ReturnsNull()
        {
            // Arrange
            var expression = new Expression("A && B &&");

            // Act
            var truthTable = TruthTable.FillTable(expression);

            // Assert
            Assert.IsNull(truthTable);
        }

        [TestMethod()]
        public void FillTable_ExpressionWithNoVariables_ReturnsNull()
        {
            // Arrange
            var expression = new Expression("true && false || true");

            // Act
            var truthTable = TruthTable.FillTable(expression);

            // Assert
            Assert.IsNull(truthTable);
        }
        [TestMethod()]
        public void FillTable_ExpressionWithEmptyVariableName_ReturnsNull()
        {
            // Arrange
            var expression = new Expression("A && B || !");

            // Act
            var truthTable = TruthTable.FillTable(expression);

            // Assert
            Assert.IsNull(truthTable);
        }
        [TestMethod()]
        public void FillTable_ExpressionWithConsecutiveOperators_ReturnsTruthTable()
        {
            // Arrange
            var expression = new Expression("A && && B || !C");

            // Act
            var truthTable = TruthTable.FillTable(expression);

            // Assert
            Assert.IsNull(truthTable);
        }

        [TestMethod()]
        public void GetDNF_InvalidExpression_ReturnsNullDNFExpression()
        {
            // Arrange
            var logicalExpression = new LogicalExpression("A && && B || !C");

            // Act
            var dnf = logicalExpression.GetDNF();

            // Assert
            Assert.IsNull(dnf);
        }

        [TestMethod()]
        public void GetDNF_ExpressionWithInvalidVariableName_ReturnsNullDNFExpression()
        {
            // Arrange
            var logicalExpression = new LogicalExpression("A && B$ || !C");

            // Act
            var dnf = logicalExpression.GetDNF();

            // Assert
            Assert.IsNull(dnf);
        }

        [TestMethod()]
        public void GetDNF_ExpressionWithInvalidVariableType_ReturnsNullDNFExpression()
        {
            // Arrange
            var logicalExpression = new LogicalExpression("A && B || 123");

            // Act
            var dnf = logicalExpression.GetDNF();

            // Assert
            Assert.IsNull(dnf);
        }


        [TestMethod()]
        public void GetDNF_NullExpression_ReturnsNullDNFExpression()
        {
            // Arrange
            var logicalExpression = new LogicalExpression(null);

            // Act
            var dnf = logicalExpression.GetDNF();

            // Assert
            Assert.IsNull(dnf);
        }

        [TestMethod()]
        public void GetKNF_InvalidExpression_ReturnsNullKNFExpression()
        {
            // Arrange
            var logicalExpression = new LogicalExpression("A && && B || !C");

            // Act
            var knf = logicalExpression.GetKNF();

            // Assert
            Assert.IsNull(knf);
        }

        [TestMethod()]
        public void GetKNF_ExpressionWithInvalidVariableName_ReturnsNullKNFExpression()
        {
            // Arrange
            var logicalExpression = new LogicalExpression("A && B$ || !C");

            // Act
            var knf = logicalExpression.GetKNF();

            // Assert
            Assert.IsNull(knf);
        }

        [TestMethod()]
        public void GetKNF_ExpressionWithInvalidVariableType_ReturnsNullKNFExpression()
        {
            // Arrange
            var logicalExpression = new LogicalExpression("A && B || 123");

            // Act
            var knf = logicalExpression.GetKNF();

            // Assert
            Assert.IsNull(knf);
        }


        [TestMethod()]
        public void GetKNF_NullExpression_ReturnsNullKNFExpression()
        {
            // Arrange
            var logicalExpression = new LogicalExpression(null);

            // Act
            var knf = logicalExpression.GetKNF();

            // Assert
            Assert.IsNull(knf);
        }
    }
}