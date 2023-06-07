import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ParticipantClient, ParticipantCreateInput, ParticipantDto, ParticipantUpdateInput } from 'src/libs/services/generated-client.service';

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
  participant : ParticipantUpdateInput | undefined ;
  currentId: number = 0;
  
  constructor(private service: ParticipantClient)
  {
    
  }
  
  ngOnInit(): void {

  this.loadData();
   
 }

 onAdd() : void
{
  
  this.modification = true;
  
}

onEdit(input:any) : void
{
 
  debugger
  this.modification = true;
  this.currentId = input.id;
  this.participant= input;
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
