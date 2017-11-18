import { OrganizationType } from './organization.enum';

export class RegisterModel {
    emailAddress: string;
    password: string;
    repeatPassword: string;
    name: string;
    surname: string;
    addOrganization: boolean;
    organizationName?: string;
    organizationDescription?: string;
    organizationType?: OrganizationType;
}
