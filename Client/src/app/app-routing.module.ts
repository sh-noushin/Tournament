import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TournamentListComponent } from './components/tournament-list/tournament-list.component';
import { ParticipantClient } from 'src/libs/services/generated-client.service';
import { ParticipantListComponent } from './components/participant-list/participant-list.component';
import { AttemptListComponent } from './components/attempt-list/attempt-list.component';

const routes: Routes = [
  {path:'tournaments', component: TournamentListComponent},
  {path:'participants', component: ParticipantListComponent},
  {path:'attempts', component: AttemptListComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
