import { ApplicationConfig } from '@angular/core';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { providePrimeNG } from 'primeng/config';
import Aura from "@primeng/themes/aura";
import { definePreset } from "@primeng/themes";

const MyPreset = definePreset(Aura, {
  primitive: {
    borderRadius: {
      none: "0",
      xs: "2px",
      sm: "4px",
      md: "6px",
      lg: "8px",
      xl: "12px"
    },
   orange: {
            50: "#fff7ed",
            100: "#ffedd5",
            200: "#fed7aa",
            300: "#fdba74",
            400: "#fb923c",
            500: "#f97316",
            600: "#ea580c",
            700: "#c2410c",
            800: "#9a3412",
            900: "#7c2d12",
            950: "#431407"
        },
        slate: {
            50: "#f8fafc",
            100: "#f1f5f9",
            200: "#e2e8f0",
            300: "#cbd5e1",
            400: "#94a3b8",
            500: "#64748b",
            600: "#475569",
            700: "#334155",
            800: "#1e293b",
            900: "#0f172a",
            950: "#020617"
        },
        gray: {
            50: "#f9fafb",
            100: "#f3f4f6",
            200: "#e5e7eb",
            300: "#d1d5db",
            400: "#9ca3af",
            500: "#6b7280",
            600: "#4b5563",
            700: "#374151",
            800: "#1f2937",
            900: "#111827",
            950: "#030712"
        }
    },
    semantic: {
        transitionDuration: "0.2s",
        focusRing: {
            width: "1px",
            style: "solid",
            color: "{primary.color}",
            offset: "2px",
            shadow: "none"
        },
        disabledOpacity: "0.6",
        iconSize: "1rem",
        anchorGutter: "2px",
        primary: {
            50: "#fff7ed",
            100: "#ffedd5",
            200: "#fed7aa",
            300: "#fdba74",
            400: "#fb923c",
            500: "#f97316",
            600: "#ea580c",
            700: "#c2410c",
            800: "#9a3412",
            900: "#7c2d12",
            950: "#431407"
        },
        formField: {
            paddingX: "0.75rem",
            paddingY: "0.5rem",
            sm: { fontSize: "0.875rem", paddingX: "0.625rem", paddingY: "0.375rem" },
            lg: { fontSize: "1.125rem", paddingX: "0.875rem", paddingY: "0.625rem" },
            borderRadius: "{border.radius.md}",
            focusRing: { width: "0", style: "none", color: "transparent", offset: "0", shadow: "none" },
            transitionDuration: "{transition.duration}"
        },
        colorScheme: {
            light: {
                surface: {
                    0: "#ffffff",
                    50: "#f8fafc",
                    100: "#f1f5f9",
                    200: "#e2e8f0",
                    300: "#cbd5e1",
                    400: "#94a3b8",
                    500: "#64748b",
                    600: "#475569",
                    700: "#334155",
                    800: "#1e293b",
                    900: "#0f172a",
                    950: "#020617"
                },
                primary: {
                    color: "{primary.500}",
                    contrastColor: "#ffffff",
                    hoverColor: "{primary.600}",
                    activeColor: "{primary.700}"
                },
                highlight: {
                    background: "{primary.50}",
                    focusBackground: "{primary.100}",
                    color: "{primary.700}",
                    focusColor: "{primary.800}"
                },
                formField: {
                    focusBorderColor: "{primary.color}",
                    floatLabelFocusColor: "{primary.600}"
                },
                text: {
                    color: "{slate.700}",
                    hoverColor: "{slate.800}",
                    mutedColor: "{slate.500}"
                }
            },
            dark: null
        }
    },
    components: {
        button: {
            root: {
                primary: {
                    background: "{primary.500}",
                    hoverBackground: "{primary.600}",
                    activeBackground: "{primary.700}",
                    borderColor: "{primary.500}",
                    color: "#ffffff"
                }
            }
        },
        inputtext: {
            root: {
                focusBorderColor: "{primary.500}",
                hoverBorderColor: "{primary.400}"
            }
        },
        dropdown: {
            root: {
                focusBorderColor: "{primary.500}",
                hoverBorderColor: "{primary.400}"
            }
        },
        checkbox: {
            root: {
                checkedBackground: "{primary.500}",
                checkedBorderColor: "{primary.500}"
            }
        },
        radiobutton: {
            root: {
                checkedBackground: "{primary.500}",
                checkedBorderColor: "{primary.500}"
            }
        },
        badge: {
            colorScheme: {
                light: {
                    primary: { background: "{primary.500}", color: "#ffffff" }
                }
            }
        },
        progressbar: {
            value: { background: "{primary.500}" }
        },
        toast: {
            colorScheme: {
                light: {
                    info: { background: "{primary.100}", color: "{primary.700}" }
                }
            }
        },
        tag: {
            colorScheme: {
                light: {
                    primary: { background: "{primary.100}", color: "{primary.700}" }
                }
            }
        }
    }
});


export default MyPreset;