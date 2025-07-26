import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MAT_LUXON_DATE_ADAPTER_OPTIONS, LuxonDateAdapter, MAT_LUXON_DATE_FORMATS } from '@angular/material-luxon-adapter';

@NgModule({ declarations: [
        AppComponent
    ],
    bootstrap: [AppComponent], 
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        BrowserAnimationsModule,
        AppRoutingModule,
        MatDatepickerModule,
        FormsModule
    ], 
    providers: [
        BrowserAnimationsModule,
        provideHttpClient(withInterceptorsFromDi()),
        { provide: MAT_DATE_LOCALE, useValue: 'en-GB' },
        { provide: MAT_LUXON_DATE_ADAPTER_OPTIONS, useValue: {useUtc: false, firstDayOfWeek: 1} },
        { provide: DateAdapter, useClass: LuxonDateAdapter, deps: [MAT_DATE_LOCALE, MAT_LUXON_DATE_ADAPTER_OPTIONS] },
        { provide: MAT_DATE_FORMATS, useValue: MAT_LUXON_DATE_FORMATS },
    ] 
    })
export class AppModule { }
