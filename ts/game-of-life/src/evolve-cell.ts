export function evolveCell(cell: number, neighbors: number[]): number {
    if (cell === 1 && neighbors.filter(n => n === 1).length < 2) {
        return 0;
    }
    return cell;
}
