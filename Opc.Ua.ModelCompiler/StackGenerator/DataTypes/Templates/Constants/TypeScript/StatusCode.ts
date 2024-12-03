export enum StatusCodes {}
// ***START***
export class StatusUtils {
   public static toCode(value: number | object | undefined): number {
      if (!value) return 0;
      let code: number | undefined = typeof value === 'number' ? value : undefined;
      if (code === undefined) {
         const field = value["code"];
         code = typeof field === 'number' ? field : undefined;
      }
      return code ?? 0;
   }
   public static toHex(code: number): string {
      let text: string = code.toString(16).toUpperCase();
      while (text.length < 8) {
         text = '0' + text;
      }
      return '0x' + text;
   }
   public static isGood(value: number | object | undefined): boolean {
      return (StatusUtils.toCode(value) & 0xD0000000) === 0;
   }
   public static isUncertain(value: number | object | undefined): boolean {
      return (StatusUtils.toCode(value) & 0x40000000) !== 0;
   }
   public static isBad(value: number | object | undefined): boolean {
      return (StatusUtils.toCode(value) & 0x80000000) !== 0;
   }
   public static codeBits(value: number | object | undefined): number {
      return (StatusUtils.toCode(value) ?? 0 & 0xFFFF0000);
   }
   public static infoBits(value: number | object | undefined): number {
      return (StatusUtils.toCode(value) ?? 0 & 0x0000FFFF);
   }
   public static toText(value: number | object | undefined): string {
      const code = StatusUtils.toCode(value);
      return Object.keys(StatusCodes).find(key => StatusCodes[key] === code) ?? StatusUtils.toHex(code);
   }
}
// ***END***