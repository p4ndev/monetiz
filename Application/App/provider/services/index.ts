import { ValidationService } from "./validation.service";
import { FloatPanelService } from "./float-panel.service";
import { FullscreenService } from "./fullscreen.service";
import { DeviceService } from "./device.service";

import { AccessService } from "./account/access.service";
import { ActivityService } from "./account/activity.service";
import { RecoveryService } from "./account/recovery.service";

import { TenantService } from "./lobby/tenant.service";
import { CategoryService } from "./lobby/category.service";

import { GameService } from "./room/game.service";
import { ActionService } from "./room/action.service";

import { PixService } from "./financial/pix.service";
import { BalanceService } from "./financial/balance.service";
import { CheckoutService } from "./financial/checkout.service";
import { MercadoPagoService } from "./financial/mercado-pago.service";
import { BalanceEgressService } from "./financial/balanace-egress.service";
import { BalanceIngressService } from "./financial/balanace-ingress.service";

import { PlayerService } from "./lobby/player.service";
import { HowToPlayService } from "./how-to-play.service";
import { AnalyticService } from "./analytics.service";

export{
  ValidationService, FloatPanelService, DeviceService,
  AccessService, ActivityService, RecoveryService,
  TenantService, CategoryService,
  GameService, ActionService,
  BalanceService, CheckoutService, MercadoPagoService,
  HowToPlayService, PixService, BalanceIngressService,
  BalanceEgressService, FullscreenService, PlayerService,
  AnalyticService
}