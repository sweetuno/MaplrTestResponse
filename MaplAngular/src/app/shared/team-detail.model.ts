import { PlayerDetail } from "./player-detail.model";

export class TeamDetail {
    id:number = 0;
    coach:string;
    year:number;
    players:PlayerDetail[];
}
