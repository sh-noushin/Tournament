import { Component, Inject } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { PagedResultResponseOfTopAttemptsDto, TopAttemptsDto, TournamentClient } from 'src/libs/services/generated-client.service';
import { AttemptComponent } from '../attempt/attempt.component';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-attempt-list',
  templateUrl: './attempt-list.component.html',
  styleUrls: ['./attempt-list.component.scss']
})
export class AttemptListComponent {
  results: PagedResultResponseOfTopAttemptsDto[] = [];

  displayedColumns: string[] = ['tournamentName', 'participantName', 'participantLastName', 'distance', 'edit', 'delete'];
  listData: MatTableDataSource<any> = new MatTableDataSource<any>();
  currentId: number = 0;
  filter: string ="";

  constructor(private service: TournamentClient,
    private readonly dialog: MatDialog,
    private http: HttpClient
  ) {

  }

  ngOnInit(): void {

    this.loadData();

  }

  onAdd(): void {

    const dialogRef = this.dialog.open(AttemptComponent, {
      data: { id: this.currentId },

      height: '500px',
      width: '500px',
    });

    dialogRef.afterClosed().subscribe((result: any) => {
      this.loadData();
    });


  }

  onEdit(input: any): void {


  } 
  onDelete(id: number): void {


  }

  onCancelModification(event: any) {
    this.loadData();
  }

  loadData() {

    this.service.getTopAttempts(this.filter).subscribe(data => {
    this.listData = new MatTableDataSource(data.items);

    });


  }
  

}

