import { ModuleWithProviders, NgModule, Optional, SkipSelf, NO_ERRORS_SCHEMA } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UserService } from './services/user-service/user.service';
import { MyCharityService } from './services/charity-service/my-charity.service';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { FooterComponent } from './footer/footer.component';
import { MatIconModule } from '@angular/material';
import { NewsService } from "./services/news-service/news-service.service";

@NgModule({
    imports: [
        CommonModule,
        RouterModule,
        FormsModule,
        NgbModule.forRoot(),
        HttpClientModule,
        MatIconModule
    ],
    declarations: [ToolbarComponent, FooterComponent],
    exports: [ToolbarComponent, FooterComponent],
    providers: [UserService, MyCharityService, NewsService], 
    schemas: [NO_ERRORS_SCHEMA]
})
export class CoreModule {

    constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
        if (parentModule) {
            throw new Error(
                'CoreModule is already loaded. Import it in the AppModule only');
        }
    }

    static forRoot(): ModuleWithProviders {
        return {
            ngModule: CoreModule
        };
    }
}
