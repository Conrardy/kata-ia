import { evolveCell } from "./evolve-cell";

describe('evolveCell', () => {
    const underpopulationTestCases = [
        { cell: 1, neighbors: [0, 0, 0, 0, 0], expected: 0 },
        { cell: 1, neighbors: [1, 0, 0, 0, 0], expected: 0 }
    ];

    underpopulationTestCases.forEach(({ cell, neighbors, expected }) => {
        it(`should return ${expected} if the cell is ${cell} and has neighbors ${neighbors}`, () => {
            expect(evolveCell(cell, neighbors)).toBe(expected);
        });
    });

    const overcrowdingTestCases = [
        { cell: 1, neighbors: [1, 1, 1, 1, 0], expected: 0 },
        { cell: 1, neighbors: [1, 1, 1, 1, 1], expected: 0 }
    ];

    overcrowdingTestCases.forEach(({ cell, neighbors, expected }) => {
        it(`should return ${expected} if the cell is ${cell} and has neighbors ${neighbors}`, () => {
            expect(evolveCell(cell, neighbors)).toBe(expected);
        });
    });
});
