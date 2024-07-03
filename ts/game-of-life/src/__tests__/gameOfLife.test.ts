describe('GameOfLife', () => {
    it('should be true', () => {
        expect(true).toBe(true);
    });


    for (const neighbours of [3, 2]) {
        it(`Any live cell with ${neighbours} live neighbours lives on to the next generation`, () => {
            const cell = new LiveCell();

            const nextGeneration = cell.nextGeneration(neighbours);

            const expectedLiveCell = new LiveCell();
            expect(nextGeneration).toStrictEqual(expectedLiveCell);
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
