import { Component, EventEmitter, Inject, Input, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ParticipantClient, ParticipantCreateInput, ParticipantUpdateInput } from 'src/libs/services/generated-client.service';

@Component({
  selector: 'app-participant',
  templateUrl: './participant.component.html',
  styleUrls: ['./participant.component.scss']
})
export class ParticipantComponent {
  @Input() id: number = 0;
  comingParticipant:ParticipantCreateInput= {
    name: '',
    lastName: '',
    init: function (_data?: any): void {
      throw new Error('Function not implemented.');
    },
    toJSON: function (data?: any) {
      throw new Error('Function not implemented.');
    }
  };
  

  
   constructor(private service: ParticipantClient,
    private _snackBar: MatSnackBar,
    public dialogRef: MatDialogRef<ParticipantComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
     

    }
 
    ngOnInit(): void {

      this.id = this.data.id;
      this.comingParticipant = this.data.participant;
      
  
  
    }
   save()
   {
    
    if(this.id == 0)
    {
     
      var participant = new ParticipantCreateInput();
      participant.name = this.comingParticipant.name;
      participant.lastName = this.comingParticipant.lastName ;

      this.service.create(participant).subscribe(
        result =>{
          this.comingParticipant.name = "";
          this.comingParticipant.lastName ="";
        },
        error =>{ 
          this._snackBar.open(error + "Maybe this participant already exists.", 'Undo');       
        }
      );
    }
    else
    {
     debugger
      var participant = new ParticipantUpdateInput();
      participant.name = this.comingParticipant.name;
      participant.lastName = this.comingParticipant.lastName ;
      console.log(participant)

      this.service.update(this.id, participant).subscribe(
        result =>{          
          this.comingParticipant.name = "";
          this.comingParticipant.lastName ="";
          this.dialogRef.close();
        
        },
        error =>{
           this._snackBar.open(error + "Maybe this participant already exists.", 'Undo');          
        }
      );
    }

   }

   cancel()
   {
    this.dialogRef.close();

   }
}
