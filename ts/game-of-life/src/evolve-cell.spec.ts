import { evolveCell } from "./evolve-cell";

describe('evolveCell', () => {
    it.each([
        { cell: 1, neighbors: [0, 0, 0, 0, 0], expected: 0 },
        { cell: 1, neighbors: [1, 0, 0, 0, 0], expected: 0 }
    ])('should return $expected if the cell is $cell and has neighbors $neighbors', ({ cell, neighbors, expected }) => {
        expect(evolveCell(cell, neighbors)).toBe(expected);
    });

    it.each([
        { cell: 1, neighbors: [1, 1, 1, 1, 0], expected: 0 },
        { cell: 1, neighbors: [1, 1, 1, 1, 1], expected: 0 }
    ])('should return $expected if the cell is $cell and has neighbors $neighbors', ({ cell, neighbors, expected }) => {
        expect(evolveCell(cell, neighbors)).toBe(expected);
    });

    it.each([
        { cell: 1, neighbors: [1, 1, 0, 0, 0], expected: 1 },
        { cell: 1, neighbors: [1, 1, 1, 0, 0], expected: 1 }
    ])('should return $expected if the cell is $cell and has neighbors $neighbors', ({ cell, neighbors, expected }) => {
        expect(evolveCell(cell, neighbors)).toBe(expected);
    });

    it.each([
        { cell: 0, neighbors: [1, 1, 1, 0, 0], expected: 1 }
    ])('should return $expected if the cell is $cell and has neighbors $neighbors', ({ cell, neighbors, expected }) => {
        expect(evolveCell(cell, neighbors)).toBe(expected);
    });
});
