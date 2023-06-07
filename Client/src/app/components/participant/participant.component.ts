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
  @Input() comingParticipant: ParticipantCreateInput | undefined;

  @Input() modification : boolean = false;
  @Output() cancelEvent = new EventEmitter<boolean>();
  

  participantForm = new FormGroup({
    name: new FormControl(''),
    lastName: new FormControl('')
    
   });

   constructor(private service: ParticipantClient,
    private _snackBar: MatSnackBar,
    public dialogRef: MatDialogRef<ParticipantComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
     

    }

   save()
   {
    if(this.id == 0)
    {
      var participant = new ParticipantCreateInput();
      participant.name = this.participantForm.value.name ? this.participantForm.value.name : "" ;
      participant.lastName = this.participantForm.value.lastName ? this.participantForm.value.lastName : "" ;

      this.service.create(participant).subscribe(
        result =>{
          this.participantForm.reset();
          this.modification = false;
          this.cancelEvent.emit(this.modification);
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
      participant.name = this.participantForm.value.name ? this.participantForm.value.name : "" ;
      participant.lastName = this.participantForm.value.lastName ? this.participantForm.value.lastName : "" ;
      console.log(participant)

      this.service.update(this.id, participant).subscribe(
        result =>{
          
          this.participantForm.reset();
          this.modification = false;
          this.cancelEvent.emit(this.modification);
        
        },
        error =>{
           this._snackBar.open(error + "Maybe this participant already exists.", 'Undo');          
        }
      );
    }

   }

   cancel()
   {
    this.modification = false;
    this.cancelEvent.emit(this.modification);

   }
}
