describe('GameOfLife', () => {
    it('should be true', () => {
        expect(true).toBe(true);
    });


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

            expect(nextGeneration).toBeUndefined();
        });
    }
});

export class LiveCell {
    public nextGeneration(neighbours: number) {
        if (neighbours === 2 || neighbours === 3) {
            return this;
        }

        return undefined;
    }
}
