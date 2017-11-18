import { EventType } from "./event-type.type";

export class EventModel {
  id: number;
  name: string;
  description: string;
  startDate: Date;
  endDate: Date;
  eventType: EventType;
}
