import { StartingGame } from './models/starting-game';
import { GuessResult } from './models/guess-result';
import { FruitBasketService } from './services/fruit-basket.service';
import { Player } from './models/player';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
	selector: 'fruit-basket',
	templateUrl: './fruit-basket.component.html',
	styleUrls: ['./fruit-basket.component.scss']
})
export class FruitBasketComponent implements OnInit {

	constructor(private basketService: FruitBasketService) {}

	public players: Player[] = [];
	public guessResult: GuessResult;
	public gameIsStarted: boolean = false;
	realBasketWeight: number;
	playersValid: boolean = false;
	isCorrectPlayersNumber: boolean = false;
	showMessage: boolean = false;
	minPlayersCount: number = 2;
	maxPlayersCount: number = 8;

	ngOnInit() {
		this.basketService.getRealBasketWeight().subscribe((realBasketWeight: number) => {      
			this.realBasketWeight = realBasketWeight;
		});
	}

	addPlayer() {
		const newPlayer = new Player('', 'Random');
		this.players.push(newPlayer);
		this.checkPlayersAreCorrect();		
	}

	deletePlayer(player: Player) {
		if(!player) return;
		const index = this.players.indexOf(player);
		this.players.splice(index,1);
		this.checkPlayersAreCorrect();
	}

	startGame() {		
		this.gameIsStarted = true;
		const playersModel = new StartingGame(this.players, this.realBasketWeight);
		this.basketService.startGame(playersModel)
			.subscribe((guessResult: string) => {        
				var result = JSON.parse(guessResult);
				this.guessResult = result;
				this.gameIsStarted = false;
			});
	}

	checkPlayersFields() {		
		if(this.players.filter(x => x.name.trim() === "").length > 0) {
			this.playersValid = false;
			this.showMessage = true;
		} else {
			this.playersValid = true;
			this.showMessage = false;
		}
	}

	private checkPlayersAreCorrect() {
		if(this.players.length >= this.minPlayersCount && this.players.length <= this.maxPlayersCount) {
			this.isCorrectPlayersNumber = true;
		} else {
			this.isCorrectPlayersNumber = false;
		}

		this.checkPlayersFields();	
	}

	
	

	

}
