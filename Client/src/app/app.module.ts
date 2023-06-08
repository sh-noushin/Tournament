import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TournamentListComponent } from './components/tournament-list/tournament-list.component';
import { TournamentComponent } from './components/tournament/tournament.component';
import { ParticipantListComponent } from './components/participant-list/participant-list.component';
import { ParticipantComponent } from './components/participant/participant.component';
import { HttpClientModule } from '@angular/common/http';
import {MatTableModule} from '@angular/material/table';
import { ReactiveFormsModule } from '@angular/forms';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatIconModule} from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import {MAT_DIALOG_DATA, MatDialogModule, MatDialogRef} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { AttemptListComponent } from './components/attempt-list/attempt-list.component';
import { AttemptComponent } from './components/attempt/attempt.component';
import { MatSelectModule } from '@angular/material/select';




@NgModule({
  declarations: [
    AppComponent,
    TournamentListComponent,
    TournamentComponent,
    ParticipantListComponent,
    ParticipantComponent,
    AttemptListComponent,
    AttemptComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatTableModule,
    ReactiveFormsModule,
    MatSnackBarModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatButtonModule,
    MatDialogModule,
    MatFormFieldModule,
    MatIconModule,
    FormsModule,
    MatSelectModule
    
    
    
  ],
  
  providers: [{provide: MatDialogRef, useValue: {}},
    {provide: MAT_DIALOG_DATA, useValue: []},],
  bootstrap: [AppComponent]
})
export class AppModule { }
