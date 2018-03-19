import { NgModule } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { routing } from './app.routing';
import { AppComponent } from './app.component';
import { HomeComponent } from './Components/home.component';


@NgModule({
    imports: [BrowserModule, ReactiveFormsModule, HttpModule, routing],
    declarations: [AppComponent, HomeComponent],
    providers: [{ provide: APP_BASE_HREF, useValue: '/' }],
    bootstrap: [AppComponent]
})

export class AppModule { }