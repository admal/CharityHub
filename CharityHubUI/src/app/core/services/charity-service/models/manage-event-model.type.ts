import { EventUserModel } from "./event-user-model.type";

export class ManageEventModel {
  name: string;
  id: number;
  users: EventUserModel[];
}
