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

  constructor(private service: TournamentClient,
    private _snackBar: MatSnackBar,
    public dialogRef: MatDialogRef<TournamentComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
     

    }
   
  ngOnInit(): void {

    this.id = this.data.id;
    this.comingTournament = this.data.name;


  }
 
 
  save() {

 
    if(this.id == 0)
    {
      
      var tournament = new TournamentCreateInput();
      tournament.name = this.comingTournament;
      this.service.create(tournament).subscribe(
        result =>{
          this.comingTournament = "";
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
          this.dialogRef.close();
      
        },
        error =>{
           this._snackBar.open(error + "Maybe name already exists.", 'Undo');          
        }
      );
    }

    
  }

  cancel() {
    this.dialogRef.close();
  }

}
