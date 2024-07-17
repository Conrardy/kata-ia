export function evolveCell(cell: number, neighbors: number[]): number {
    const liveNeighbors = neighbors.filter(n => n === 1).length;

    if (cell === 1 && (liveNeighbors < 2 || liveNeighbors > 3)) {
        return 0;
    }
    if (cell === 0 && liveNeighbors === 3) {
        return 1;
    }
    if (cell === 1 && (liveNeighbors === 2 || liveNeighbors === 3)) {
        return 1;
    }
    return 0;
}
