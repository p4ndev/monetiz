import { StyleSheet } from 'react-native';

export const HelperStyle = StyleSheet.create({
    base: {
        marginLeft: 10,
        marginRight: 10,
        marginTop: 15,
        marginBottom: 80
    },
    topSpace: {
        paddingTop: 10
    },
    fully: {
        flex: 1
    },
    w100: {
        width: '100%'
    },
    centered: {
        alignItems: 'center',
        justifyContent: 'center'
    },
    centerRight: {
        alignItems: 'flex-end',
        justifyContent: 'center'
    },
    centerLeft: {
        alignItems: 'flex-start',
        justifyContent: 'center'
    },
    fullyCentered: {
        flex: 1,
        alignItems: 'center',
        justifyContent: 'center'
    },
    
    light       : { fontFamily: 'SignikaNegative_300Light, Signika Negative',     fontWeight: 300,    fontStyle: 'normal' },
    regular     : { fontFamily: 'SignikaNegative_400Regular, Signika Negative',   fontWeight: 400,    fontStyle: 'normal' },
    medium      : { fontFamily: 'SignikaNegative_500Medium, Signika Negative',    fontWeight: 500,    fontStyle: 'normal' },
    semiBold    : { fontFamily: 'SignikaNegative_600SemiBold, Signika Negative',  fontWeight: 600,    fontStyle: 'normal' },
    bold        : { fontFamily: 'SignikaNegative_700Bold, Signika Negative',      fontWeight: 700,    fontStyle: 'normal' },

    uppercase   : { textTransform: 'uppercase' },

    button: {
        marginBottom: 15,
        width: '100%',
        height: 60,    
        borderColor: 'white',
        borderRadius: 10,
        borderWidth: 3
    },
    lobbyButton:{
        borderBottomWidth: 7,
        borderRadius: 20,
        marginBottom: 15,
        width: '100%'        
    },
    lobbyButtonGradient: {
        justifyContent: 'space-between',
        flexDirection: 'row',
        alignItems: 'center',
        width: '100%'
    },

    buttonLobbyLabel: {
        fontSize: 22,
        letterSpacing: 1,
        paddingLeft: 25
    },
    buttonLabel: {
        fontSize: 14,
        letterSpacing: 1,
        color: 'white',
    },
    darkButtonLabel: {
        fontSize: 14,
        letterSpacing: 1,
        color: '#545454'
    },
    successButtonLabel: {
        fontSize: 14,
        letterSpacing: 1,
        color: '#008e23'
    },
    warningButtonLabel: {
        fontSize: 14,
        letterSpacing: 1,
        color: '#827d00'
    },

    lobbyIcon: {
        width: 140,
        height: 140,
        marginRight: 15
    },

    input: {
        color: '#8600FF',
        fontSize: 15,
        borderRadius: 8,
        paddingVertical: 18,
        paddingHorizontal: 10
    },
    inputWrap: {
        borderRadius: 8,
        borderWidth: 3,
        borderColor: 'white',
        backgroundColor: 'white',
        marginBottom: 10
    },

    buttonRounded: {
        borderRadius: 10,
        width: '100%',
        height: 54
    },
    lobbyButtonRounded: {
        borderRadius: 10,
        width: '100%'
    },

    primaryButtonWrapper:{
        borderColor: '#B700E9',
        borderStyle: 'solid',
        borderWidth: 4
        
    },
    secondaryButtonWrapper:{
        borderColor: '#8600FF',
        borderStyle: 'solid',
        borderWidth: 4
    },
    disableButtonWrapper:{
        borderColor: '#bfbfbf',
        borderStyle: 'solid',
        borderWidth: 4
    },    
    successButtonWrapper:{
        borderColor: '#06d63d',
        borderStyle: 'solid',
        borderWidth: 4
    },
    dangerButtonWrapper:{
        borderColor: '#e62e2e',
        borderStyle: 'solid',
        borderWidth: 4
    },
    warningButtonWrapper:{
        borderColor: '#d3cd15',
        borderStyle: 'solid',
        borderWidth: 4
    },
    pureButtonWrapper:{
        borderStyle: 'solid',
        borderWidth: 4
    },

    baseHeadline: {
        marginBottom: 10
    },
    headline: {
        fontSize: 30,
        paddingLeft: 10,
        letterSpacing: 1
    },
    headlineLight: {
        color: 'white'
    },
    headlineDark: {
        color: 'black'
    },

    headerStage: {
        flexDirection: 'row',
        paddingBottom: 15
    },
    headerLeft: {
        flexBasis: '85%'
    },
    headerSummary: {
        paddingLeft: 10,
        opacity: 0.6
    },
    headerRight: {
        flexBasis: '15%',
        paddingRight: 10,
        alignItems: 'center',
        justifyContent: 'center'
    },

    opaque: {
        opacity: 0.7
    },
    highOpaque: {
        opacity: 0.35
    },
});