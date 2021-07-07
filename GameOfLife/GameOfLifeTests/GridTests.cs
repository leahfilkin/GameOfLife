using System;
using System.Collections.Generic;
using System.Drawing;
using GameOfLife;
using Xunit;
using Point = GameOfLife.Point;

namespace GameOfLifeTests
{
    public class GridTests
    {
        [Fact]
        public void IsSameDimensionsAsInputsGivenToIt()
        {
            var grid = new Grid(10,20, new List<Point> {new Point(0,0)});
            
            Assert.Equal(10, grid.Cells.Count);
            Assert.Equal(20, grid.Cells[0].Count);
        }

        [Fact]
        public void CellCoordinatesGivenForInitialStateAreLive()
        {
            var grid = new Grid(10,20, new List<Point> {new Point(0,0)});
            
            Assert.Equal(Cell.Alive, grid.Cells[0][0]);
        }

        [Fact]
        public void CellsNotGivenAsLiveInputAreDead()
        {
            var grid = new Grid(10,20, new List<Point> {new Point(0,0)});
            
            Assert.Equal(Cell.Dead, grid.Cells[0][1]);
        }
        
        [Theory]
        [MemberData(nameof(AdjacentCells))]
        public void CanFindAdjacentCellsToAGivenCell(AdjacentCellsData adjacentCellsData)
        {
            var grid = 
                new Grid(adjacentCellsData.NumberOfRows, adjacentCellsData.NumberOfColumns,
                    adjacentCellsData.LiveCellInput);
            
            var adjacentCells = 
                grid.GetAdjacentCells(adjacentCellsData.Line,adjacentCellsData.Column);
            
            Assert.Equal(adjacentCellsData.ExpectedCells,adjacentCells);
        }

        public class AdjacentCellsData
        {
            public List<Cell> ExpectedCells;
            public int NumberOfRows;
            public int NumberOfColumns;
            public int Line;
            public int Column;
            public List<Point> LiveCellInput;

        }
        
        public static IEnumerable<object[]> AdjacentCells =>
            new TheoryData<AdjacentCellsData>
            {
                new AdjacentCellsData
                {   
                    ExpectedCells = new List<Cell>
                    {
                        Cell.Dead,
                        Cell.Dead,
                        Cell.Dead
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    Line = 0,
                    Column = 0,
                    LiveCellInput = new List<Point>
                    {
                        new Point(0,0)
                    }
                },
                new AdjacentCellsData
                {   
                    ExpectedCells = new List<Cell>
                    {
                        Cell.Alive,
                        Cell.Dead,
                        Cell.Dead,
                        Cell.Alive,
                        Cell.Dead
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    Line = 0,
                    Column = 1,
                    LiveCellInput = new List<Point>
                    {
                        new Point(0,0),
                        new Point(1,1)
                    }
                },
                new AdjacentCellsData
                {   
                    ExpectedCells = new List<Cell>
                    {
                        Cell.Dead,
                        Cell.Alive,
                        Cell.Dead
                
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    Line = 0,
                    Column = 2,
                    LiveCellInput = new List<Point>
                    {
                        new Point(0,0),
                        new Point(1,1)
                    }
                },
                new AdjacentCellsData
                {  
                    ExpectedCells = new List<Cell>
                    {
                        Cell.Alive,
                        Cell.Dead,
                        Cell.Dead,
                        Cell.Dead,
                        Cell.Dead
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    Line = 1,
                    Column = 0,
                    LiveCellInput = new List<Point>
                    {
                        new Point(0,0),
                    }
                    
                },
                new AdjacentCellsData
                {
                    ExpectedCells = new List<Cell>
                    {
                        Cell.Dead,
                        Cell.Alive,
                        Cell.Dead,
                        Cell.Dead,
                        Cell.Dead,
                        Cell.Dead,
                        Cell.Alive,
                        Cell.Alive,
                    },
                    NumberOfRows = 3,
                    NumberOfColumns = 3,
                    Line = 1,
                    Column = 1,
                    LiveCellInput = new List<Point>
                    {
                        new Point(0,1),
                        new Point(2,1),
                        new Point(2,2)
                    }
                },
                new AdjacentCellsData
                {
                    ExpectedCells = new List<Cell>
                    {
                        Cell.Dead,
                        Cell.Dead,
                        Cell.Dead,
                    },
                    NumberOfRows = 5,
                    NumberOfColumns = 4,
                    Line = 4,
                    Column = 0,
                    LiveCellInput = new List<Point>
                    {
                        new Point(0,0),
                        new Point(1,1)
                    }
                },
                new AdjacentCellsData
                {
                    ExpectedCells = new List<Cell>
                    {
                        Cell.Dead,
                        Cell.Dead,
                        Cell.Dead,
                        Cell.Alive,
                        Cell.Dead,
                    },
                    NumberOfRows = 10,
                    NumberOfColumns = 13,
                    Line = 9,
                    Column = 8,
                    LiveCellInput = new List<Point>
                    {
                        new Point(9,7),
                    }
                },
                new AdjacentCellsData
                {
                    ExpectedCells = new List<Cell>
                    {
                        Cell.Alive,
                        Cell.Alive,
                        Cell.Alive,
                    },
                    NumberOfRows = 15,
                    NumberOfColumns = 18,
                    Line = 14,
                    Column = 17,
                    LiveCellInput = new List<Point>
                    {
                        new Point(13,16),
                        new Point(13,17),
                        new Point(14,16),
                    }
                },
            };
    }
}