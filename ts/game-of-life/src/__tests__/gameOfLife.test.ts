export class LiveCell {
    public nextGeneration(neighbours: number): DeadCell | LiveCell {
        if (neighbours === 2 || neighbours === 3) {
            return this;
        }

        return new DeadCell();
    }
}
export class DeadCell {
    public nextGeneration(neighbours: number): DeadCell | LiveCell {
        if (neighbours === 3) {
            return new LiveCell();
        }

        return new DeadCell();
    }
}
describe('GameOfLife', () => {
    it('should be true', () => {
        expect(true).toBe(true);
    });

    for (const neighbours of [0, 1]) {
        it(`Any live cell with ${neighbours} live neighbours dies, as if caused by underpopulation`, () => {
            const cell = new LiveCell();

            const nextGeneration = cell.nextGeneration(neighbours);

            const expectedDeadCell = new DeadCell();
            expect(nextGeneration).toStrictEqual(expectedDeadCell);
        });
    }

    for (const neighbours of [2, 3]) {
        it(`Any live cell with ${neighbours} live neighbours lives on to the next generation`, () => {
            const cell = new LiveCell();

            const nextGeneration = cell.nextGeneration(neighbours);

            const expectedLiveCell = new LiveCell();
            expect(nextGeneration).toStrictEqual(expectedLiveCell);
        });
    }


    for (const neighbours of [4, 5, 6, 7, 8]) {
        it(`Any live cell with ${neighbours} live neighbours dies, as if by overcrowding`, () => {
            const cell = new LiveCell();

            const nextGeneration = cell.nextGeneration(neighbours);

            const expectedDeadCell = new DeadCell();
            expect(nextGeneration).toStrictEqual(expectedDeadCell); 
        });
    }

    it('Any dead cell with exactly three live neighbours becomes a live cell', () => {
        const cell = new DeadCell();

        const nextGeneration = cell.nextGeneration(3);

        const expectedLiveCell = new LiveCell();
        expect(nextGeneration).toStrictEqual(expectedLiveCell);
    });

    for (const neighbours of [0, 1, 2, 4, 5, 6, 7, 8]) {
        it(`Any dead cell with ${neighbours} live neighbours stays dead`, () => {
            const cell = new DeadCell();

            const nextGeneration = cell.nextGeneration(neighbours);

            const expectedDeadCell = new DeadCell();
            expect(nextGeneration).toStrictEqual(expectedDeadCell);
        });
    }


});