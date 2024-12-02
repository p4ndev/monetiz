import { View, Text, Pressable, Image } from "react-native";
import { LinearGradient } from "expo-linear-gradient";
import { MaterialIcons } from '@expo/vector-icons';
import { useId } from "react";

import { HelperStyle } from "../../provider/styles";
import i18n from "../../provider/locales";

import { ButtonPropsInterface, LobbyButtonPropsInterface } from "../../shared/interfaces";
import { MaterialIconDynamicNameType } from "../../shared/types";
import { useAsset } from "../../shared/constants";

const Button = {
    Primary: (props : ButtonPropsInterface) => (
        <Pressable onPress={props.onClick} style={HelperStyle.button} id={(!props.id) ? useId().replaceAll(':','') + '-primary' : props.id.toString()}>
            <LinearGradient colors={['#B700E9', '#de6bff']} style={[HelperStyle.centered, HelperStyle.buttonRounded]}>
                <View style={[HelperStyle.centered, HelperStyle.primaryButtonWrapper, HelperStyle.buttonRounded]}>
                    <Text style={[HelperStyle.buttonLabel, HelperStyle.bold, HelperStyle.uppercase]}>
                        { props.label && (props.label) }
                        { props.i18n  && i18n.t(props.i18n) }
                        { props.icon  && <MaterialIcons name={(props.icon as MaterialIconDynamicNameType)} size={24} color={'#FFF'} /> }
                    </Text>
                </View>
            </LinearGradient>
        </Pressable>
    ),
    Secondary: (props : ButtonPropsInterface) => (
        <Pressable onPress={props.onClick} style={HelperStyle.button} id={(!props.id) ? useId().replaceAll(':','') + '-secondary' : props.id.toString()}>
            <LinearGradient colors={['#8600FF', '#be7ff9']} style={[HelperStyle.centered, HelperStyle.buttonRounded]}>
                <View style={[HelperStyle.centered, HelperStyle.secondaryButtonWrapper, HelperStyle.buttonRounded]}>
                    <Text style={[HelperStyle.buttonLabel, HelperStyle.bold, HelperStyle.uppercase]}>
                        { props.label && (props.label) }
                        { props.i18n  && i18n.t(props.i18n) }
                        { props.icon  && <MaterialIcons name={(props.icon as MaterialIconDynamicNameType)} size={24} color={'#FFF'} /> }
                    </Text>
                </View>
            </LinearGradient>
        </Pressable>
    ),
    Disabled: (props : ButtonPropsInterface) => (
        <Pressable onPress={props.onClick} style={HelperStyle.button} id={(!props.id) ? useId().replaceAll(':','') + '-disabled' : props.id.toString()}>
            <LinearGradient colors={['#b1b1b1', '#dddddd']} style={[HelperStyle.centered, HelperStyle.buttonRounded]}>
                <View style={[HelperStyle.centered, HelperStyle.disableButtonWrapper, HelperStyle.buttonRounded]}>
                    <Text style={[HelperStyle.darkButtonLabel, HelperStyle.bold, HelperStyle.uppercase]}>
                        { props.label && (props.label) }
                        { props.i18n  && i18n.t(props.i18n) }
                        { props.icon  && <MaterialIcons name={(props.icon as MaterialIconDynamicNameType)} size={24} color={'#FFF'} /> }
                    </Text>
                </View>
            </LinearGradient>
        </Pressable>
    ),
    Success: (props : ButtonPropsInterface) => (
        <Pressable onPress={props.onClick} style={HelperStyle.button} id={(!props.id) ? useId().replaceAll(':','') + '-success' : props.id.toString()}>
            <LinearGradient colors={['#06d63d', '#93ffae']} style={[HelperStyle.centered, HelperStyle.buttonRounded]}>
                <View style={[HelperStyle.centered, HelperStyle.successButtonWrapper, HelperStyle.buttonRounded]}>
                    <Text style={[HelperStyle.successButtonLabel, HelperStyle.bold, HelperStyle.uppercase]}>
                        { props.label && (props.label) }
                        { props.i18n  && i18n.t(props.i18n) }
                        { props.icon  && <MaterialIcons name={(props.icon as MaterialIconDynamicNameType)} size={24} color={'#FFF'} /> }
                    </Text>
                </View>
            </LinearGradient>
        </Pressable>
    ),
    Danger: (props : ButtonPropsInterface) => (
        <Pressable onPress={props.onClick} style={HelperStyle.button} id={(!props.id) ? useId().replaceAll(':','') + '-danger' : props.id.toString()}>
            <LinearGradient colors={['#e62e2e', '#fc9999']} style={[HelperStyle.centered, HelperStyle.buttonRounded]}>
                <View style={[HelperStyle.centered, HelperStyle.dangerButtonWrapper, HelperStyle.buttonRounded]}>
                    <Text style={[HelperStyle.buttonLabel, HelperStyle.bold, HelperStyle.uppercase]}>
                        { props.label && (props.label) }
                        { props.i18n  && i18n.t(props.i18n) }
                        { props.icon  && <MaterialIcons name={(props.icon as MaterialIconDynamicNameType)} size={24} color={'#FFF'} /> }
                    </Text>
                </View>
            </LinearGradient>
        </Pressable>
    ),
    Warning: (props : ButtonPropsInterface) => (
        <Pressable onPress={props.onClick} style={HelperStyle.button} id={(!props.id) ? useId().replaceAll(':','') + '-warning' : props.id.toString()}>
            <LinearGradient colors={['#d3cd15', '#f7f49e']} style={[HelperStyle.centered, HelperStyle.buttonRounded]}>
                <View style={[HelperStyle.centered, HelperStyle.warningButtonWrapper, HelperStyle.buttonRounded]}>
                    <Text style={[HelperStyle.warningButtonLabel, HelperStyle.bold, HelperStyle.uppercase]}>
                        { props.label && (props.label) }
                        { props.i18n  && i18n.t(props.i18n) }
                        { props.icon  && <MaterialIcons name={(props.icon as MaterialIconDynamicNameType)} size={24} color={'#FFF'} /> }
                    </Text>
                </View>
            </LinearGradient>
        </Pressable>
    ),
    Tenant: (props : LobbyButtonPropsInterface) => (
        <Pressable onPress={props.onClick} style={[HelperStyle.w100]} id={props.id.toString()}>
            <View style={[HelperStyle.w100, HelperStyle.lobbyButton, { borderColor: (props.colors[2]) }]}>
                <LinearGradient
                    locations={[0.3, 0.9]}
                    colors={[props.colors[1], props.colors[0]]}
                    style={[HelperStyle.w100, HelperStyle.centered, HelperStyle.lobbyButtonRounded, HelperStyle.lobbyButtonGradient]}>
                        <Text style={[HelperStyle.buttonLobbyLabel, HelperStyle.light, HelperStyle.uppercase, { color: props.colors[2] }]}>
                            { props.label && (props.label) }
                            { props.i18n  && i18n.t(props.i18n) }
                        </Text>
                        { props.icon  && <Image style={HelperStyle.lobbyIcon} source={{ uri: useAsset(props.icon) }} /> }                    
                </LinearGradient>
            </View>
        </Pressable>
    ),
};

export default Button;