import { router } from "expo-router";

export const AppMap = {
    Splash : () => router.navigate(`/`),
    HowToPlay : () => router.navigate(`/how-to-play`),
    EmptyList : () => router.navigate(`/empty-list`),
    InvalidAccess : () => router.navigate(`/invalid-access`),
    ViewportRestriction : () => router.navigate(`/viewport-restriction`),

    Account: {
        SignIn : () => router.navigate(`/account/sign-in`),
        SignUp : () => router.navigate(`/account/sign-up`),
        SignOut : () => router.navigate(`/account/sign-out`),
        Activation : () => router.navigate(`/account/activate`),
        Recovery : () => router.navigate(`/account/recovery`),
        Reset : () => router.navigate(`/account/reset`),        
        Profile : () => router.navigate(`/account/profile`),
    },

    Lobby: {
        Tenant : () => router.navigate(`/lobby/tenant`),
        Category : () => router.navigate(`/lobby/category`)
    },

    Room: {
        Game : () => router.navigate(`/room`),
        BooleanAction : () => router.navigate(`/room/boolean-action`),
    },

    Financial: {
        Home : () => router.navigate(`/financial`),
        Checkout : () => router.navigate(`/financial/checkout`),
        ShoppingCart : () => router.navigate(`/financial/shopping-cart`),
        SuccessfulCheckout : () => router.navigate(`/financial/successful-checkout`),
        UnSuccessfulCheckout : () => router.navigate(`/financial/unsuccessful-checkout`)
    }    
};