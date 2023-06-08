import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ParticipantClient, ParticipantDto, TournamentAddAttemptInput, TournamentClient, TournamentDto, TournamentWithAttemptsDto } from 'src/libs/services/generated-client.service';

@Component({
  selector: 'app-attempt',
  templateUrl: './attempt.component.html',
  styleUrls: ['./attempt.component.scss']
})
export class AttemptComponent {

  distance: number = 0;
  tournaments: TournamentDto[] = [];
  participants: ParticipantDto[] = [];
  selectedTournament: number = 0;
  selectedParticipant: number = 0;
  results: TournamentWithAttemptsDto[] = [];


  constructor(private tournamentService: TournamentClient,
    private participantService: ParticipantClient,
    private _snackBar: MatSnackBar,
    public dialogRef: MatDialogRef<AttemptComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit(): void {

    this.loadData();

  }
  setSelectedTournament(e: any) {
    
    this.selectedTournament = e.value.id;

  }

  setSelectedParticipant(e: any) {
    this.selectedParticipant = e.value.id;

  }

  loadData() {
    
    this.tournamentService.getList().subscribe(data => {
      this.results = data.items;

      for (let result in this.results) {
        var temp = new TournamentDto();
        temp.id = this.results[result].id;
        temp.name = this.results[result].name;
        this.tournaments.push(temp);

      }

    }

    );

    this.participantService.getList().subscribe(data => {
      this.participants = data.items;        
      
     }
   
     );
  }
  save()
   {
    
    debugger
      var attempt = new TournamentAddAttemptInput();
      attempt.tournametId = this.selectedTournament;
      attempt.participantId = this.selectedParticipant ;
      attempt.distance = this.distance;
      this.tournamentService.addAttempts(attempt).subscribe(
        result =>{          
          this.selectedTournament = 0;
          this.selectedParticipant =0;
          this.dialogRef.close();
        
        },
        error =>{
           this._snackBar.open(error + "Maybe this distance is negative or greater than limit.", 'Undo');          
        }
      );
    }

   
  cancel()
   {
    this.dialogRef.close();

   }

}
