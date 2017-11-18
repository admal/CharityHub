import { EventType } from "./event-type.type";

export class EventModel {
  name: string;
  description: string;
  startDate: Date;
  endDate: Date;
  eventType: EventType;
}
