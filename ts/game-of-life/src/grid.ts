export class Grid {
    private grid: number[][];

    constructor(rows: number, cols: number) {
        this.grid = Array.from({ length: rows }, () => Array(cols).fill(0));
    }

    public print(): void {
        console.log(this.grid.map(row => row.join(' ')).join('\n'));
    }
}
