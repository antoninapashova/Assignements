import { AzureAdService } from './../../auth/azure-ad.service';
import { takeUntil } from 'rxjs/operators';
import { EventMessage, EventType, InteractionStatus, RedirectRequest } from '@azure/msal-browser';
import { MsalService, MsalBroadcastService, MSAL_GUARD_CONFIG, MsalGuardConfiguration } from '@azure/msal-angular';
import { Component, EventEmitter, Output, OnInit, OnDestroy, Inject } from '@angular/core';
import { filter, Subject } from 'rxjs';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit, OnDestroy{
   
  @Output() public sidenavToggle = new EventEmitter();
  isAuthenticated=false;
  activeUser!: string;
  name!: string 
  username!: string;
  isAdmin: boolean = false;

 private readonly unsubscribe = new Subject<void>();
 
 constructor(@Inject(MSAL_GUARD_CONFIG) private msalGuardConfig: MsalGuardConfiguration,
             private authService: MsalService, 
             private broadCastService: MsalBroadcastService, 
             private azureAdService: AzureAdService ) {}
 
  ngOnDestroy(): void {
    this.unsubscribe.next(undefined);
    this.unsubscribe.complete();
  }
 
  ngOnInit(): void {
     this.broadCastService.inProgress$
     .pipe(
       filter((status: InteractionStatus)=>status===InteractionStatus.None),
       takeUntil(this.unsubscribe)
      )
     .subscribe(()=>{
        this.isAuthenticated = this.authService.instance.getAllAccounts().length>0;
        this.azureAdService.isUserLogedIn.next(!!this.isAuthenticated);
        let activAccount = this.authService.instance.getActiveAccount();    
      
        if(!activAccount && this.authService.instance.getAllAccounts().length>0)
        {
         activAccount=this.authService.instance.getAllAccounts()[0];       
         this.authService.instance.setActiveAccount(activAccount);    
         console.log(activAccount);
        }

        if(activAccount?.idTokenClaims?.roles?.includes('Admin')){
           this.isAdmin=true;
        }
        
       });
     
  }
 
 login(): void{
    if(this.msalGuardConfig.authRequest){
      this.authService.loginRedirect({...this.msalGuardConfig.authRequest} as RedirectRequest);
    }else {
       this.authService.loginRedirect();
    }
}

  logout(): void{
     this.authService.logoutRedirect({postLogoutRedirectUri: 'http://localhost:4200'});
  }


  public onToggleSidenav = () => {
    this.sidenavToggle.emit();
  }
}
