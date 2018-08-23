import { Player } from '../models/player';

export class StartingGame {
    constructor(private players: Player[], private realBasketWeight: number) {}
}