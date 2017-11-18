import { OrganizationType } from './../../user-service/models/organization.enum';

export class OrganizationModel {
  id: number;
  name: string;
  description: string;
  organizationType: OrganizationType;
  isObserving: boolean;
} 