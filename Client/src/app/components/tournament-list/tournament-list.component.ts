import { Component } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { TournamentClient, TournamentCreateInput, TournamentDto, TournamentWithAttemptsDto } from 'src/libs/services/generated-client.service';
import { TournamentComponent } from '../tournament/tournament.component';

@Component({
  selector: 'app-tournament-list',
  templateUrl: './tournament-list.component.html',
  styleUrls: ['./tournament-list.component.scss']
})
export class TournamentListComponent {
   
  results : TournamentWithAttemptsDto[] = [];

  tableData: TournamentDto[] = [];
  displayedColumns: string[] = ['id', 'name', 'edit', 'delete'];
  listData: MatTableDataSource<any> = new MatTableDataSource<any>();
  tournament : TournamentCreateInput | undefined ;
  currentId: number = 0;

  
constructor(private service: TournamentClient,
  private readonly dialog: MatDialog,
  
  )
{
  
}

ngOnInit(): void {

  this.loadData();
   
}

onAdd() : void
{
  
   const dialogRef = this.dialog.open(TournamentComponent, {
    data: { id: this.currentId, name: this.tournament?.name },

    height: '300px',  
    width: '400px',  });
    
    dialogRef.afterClosed().subscribe((result: any) => {
      this.loadData();
    });
  
  
}
onEdit(input:any) : void
{
 
  this.currentId = input.id;
  this.tournament= input;
   const dialogRef = this.dialog.open(TournamentComponent, {
    data: { id: this.currentId, name: this.tournament?.name },

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

onCancelModification(event: any)
{
   this.loadData();
}

loadData()
{
  this.tableData.length = 0;
  this.service.getList().subscribe(data => {
    this.results = data.items;
    
    for (let result in this.results )
    {
     var temp = new TournamentDto();
     temp.id = this.results[result].id;
     temp.name = this.results[result].name;
 
       this.tableData.push(temp);   
    }
    this.listData = new MatTableDataSource(this.tableData);
    
  }
 
   );
}
}
