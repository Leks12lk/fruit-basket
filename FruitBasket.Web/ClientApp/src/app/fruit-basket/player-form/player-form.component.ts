import { Player } from '../models/player';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'player-form',
  templateUrl: './player-form.component.html',
  styleUrls: ['./player-form.component.scss']
})
export class PlayerFormComponent implements OnInit {

  @Input() player: Player;
  @Output() onDeletePlayer: EventEmitter<Player> = new EventEmitter<Player>();
  @Output() onChangePlayer: EventEmitter<Player> = new EventEmitter<Player>();

  constructor() { }

  ngOnInit() {
  }

  deletePlayer() {    
    this.onDeletePlayer.emit(this.player);
  } 

  changePlayer() {
    this.onChangePlayer.emit();
  }

}
