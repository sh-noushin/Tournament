import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ParticipantClient, ParticipantCreateInput, ParticipantDto, ParticipantUpdateInput } from 'src/libs/services/generated-client.service';
import { ParticipantComponent } from '../participant/participant.component';

@Component({
  selector: 'app-participant-list',
  templateUrl: './participant-list.component.html',
  styleUrls: ['./participant-list.component.scss']
})
export class ParticipantListComponent {

  results : ParticipantDto[] = [];

  displayedColumns: string[] = ['id', 'name', 'lastName', 'edit', 'delete'];
  listData: MatTableDataSource<any> = new MatTableDataSource<any>();
  modification : boolean = false;
  
  participant: ParticipantCreateInput= {
    name: '',
    lastName: '',
    init: function (_data?: any): void {
      throw new Error('Function not implemented.');
    },
    toJSON: function (data?: any) {
      throw new Error('Function not implemented.');
    }
  };

  currentId: number = 0;
  
  constructor(private service: ParticipantClient,
    private readonly dialog: MatDialog)
  {
    
  }
  
  ngOnInit(): void {

  this.loadData();
   
 }

 onAdd() : void
{
  
  const dialogRef = this.dialog.open(ParticipantComponent, {
    data: { id: this.currentId, participant: this.participant },

    height: '300px',  
    width: '400px',  });
    
    dialogRef.afterClosed().subscribe((result: any) => {
      this.loadData();
    });
    
}

onEdit(input:any) : void
{
 
  this.currentId = input.id;
  this.participant= input;
   const dialogRef = this.dialog.open(ParticipantComponent, {
    data: { id: this.currentId, participant: this.participant },

    height: '300px',  
    width: '400px',  });
    
    dialogRef.afterClosed().subscribe((result: any) => {
      this.loadData();
    });
}
onDelete(id:number) : void
{

  this.service.delete(id).subscribe((res => {
    this.loadData();
  }));
 
}

loadData()
{
  this.service.getList().subscribe(data => {
    this.results = data.items;   
    
    this.listData = new MatTableDataSource(this.results);
    
   }
 
   );
}
onCancelModification(event: any)
{
   this.modification = false;
   this.loadData();
}
}
