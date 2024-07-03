import { DeadCell, LiveCell } from "./__tests__/gameOfLife.test";

export class Grid {
    private grid: (DeadCell | LiveCell)[][];

    constructor(rows: number, cols: number) {
        this.grid = Array.from({ length: rows }, () => Array(cols).fill(new DeadCell()));
    }

    public countNeighbours(row: number, col: number): number {
        let count = 0;
        for (let i = row - 1; i <= row + 1; i++) {
            for (let j = col - 1; j <= col + 1; j++) {
                if (i >= 0 && i < this.grid.length && j >= 0 && j < this.grid[0].length) {
                    if (this.grid[i][j] instanceof LiveCell) {
                        count += 1;
                    }
                }
            }
        }
        return count;
    }

    public setCell(row: number, col: number, value: DeadCell | LiveCell): void {
        this.grid[row][col] = value;
    }

    public getCell(row: number, col: number): DeadCell | LiveCell {
        return this.grid[row][col];
    }
    public print(): void {
        console.log(this.grid.map(row => row.join(' ')).join('\n'));
    }
}
