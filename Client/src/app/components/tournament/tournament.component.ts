import { Component, EventEmitter, Inject, Input, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TournamentClient, TournamentCreateInput, TournamentUpdateInput } from 'src/libs/services/generated-client.service';
 

@Component({
  selector: 'app-tournament',
  templateUrl: './tournament.component.html',
  styleUrls: ['./tournament.component.scss']
})
export class TournamentComponent {
  @Input() id: number = 0;
  comingTournament: string = "";

modification : boolean = false;
  //@Input() modification : boolean = false;

  @Output() cancelEvent = new EventEmitter<boolean>();

 
  constructor(private service: TournamentClient,
    private _snackBar: MatSnackBar,
    public dialogRef: MatDialogRef<TournamentComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
     

    }
 
  // tournamentForm = new FormGroup({
  //  name: new FormControl(''),
   
  // });
 
   
  ngOnInit(): void {

    

  }
 
 
  save() {

 
    if(this.id == 0)
    {
      
      var tournament = new TournamentCreateInput();
      tournament.name = this.comingTournament;
      this.service.create(tournament).subscribe(
        result =>{
          this.comingTournament = "";
          this.modification = false;
          this.cancelEvent.emit(this.modification);
        },
        error =>{ 
          this._snackBar.open(error + "Maybe name already exists.", 'Undo');       
        }
      );
    }
    else
    {
     
      var tournament = new TournamentUpdateInput();
      tournament.name = this.comingTournament ;
      this.service.update(this.id, tournament).subscribe(
        result =>{
          
          this.comingTournament= "";
          this.modification = false;
          this.cancelEvent.emit(this.modification);
        
        },
        error =>{
           this._snackBar.open(error + "Maybe name already exists.", 'Undo');          
        }
      );
    }

    
  }

  cancel() {
    this.modification = false;
    this.cancelEvent.emit(this.modification);
  }

}
