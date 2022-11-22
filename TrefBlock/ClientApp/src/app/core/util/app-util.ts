export class AppUtil {

  public static getRandomText(length: number): string {
    let text = '';
    let possible = 'abcdefghjklmnopqrstuwyz';

    for (let i = 0; i < length; i++) {
      text += possible.charAt(Math.floor(Math.random() * possible.length));
    }
    return text;
  }

  public static formatStringValue(stringValue: string, decimals: number = 0, suffix: string = ''): string {
    if (stringValue == undefined)
      stringValue = '0';

    return (parseFloat(parseFloat(stringValue).toFixed(decimals).toString())).toLocaleString('en-us', { minimumFractionDigits: decimals }) + suffix;
  }

  public static safeDivide(a: number, b: number): number {
    var result = 0;
    isNaN(a / b) ? result = 0 : result = a / b;
    return result;
  }

  public static getEnumKeyByEnumValue(myEnum: any, enumValue: any) {
    let keys = Object.keys(myEnum).filter(x => myEnum[x] == enumValue);
    return keys.length > 0 ? keys[0] : null;
  }

  /** Get a nested property from an object without returning any errors.
   * If the property or property chain doesn't exist, undefined is returned.
   * Property names with spaces may use either dot or bracket "[]" notation.
   * Note that bracketed property names without surrounding quotes will fail the lookup.
   *      e.g. embedded variables are not supported.
   * @param {object} obj The object to check
   * @param {string} prop The property or property chain to get (e.g. obj.prop1.prop1a or obj['prop1'].prop2)
   * @returns {*|undefined} The value of the objects property or undefined if the property doesn't exist
   */
  public static getProp(obj: any, prop: any) {
    if (typeof obj !== 'object') throw 'getProp: obj is not an object'
    if (typeof prop !== 'string') throw 'getProp: prop is not a string'

    // Replace [] notation with dot notation
    prop = prop.replace(/\[["'`](.*)["'`]\]/g, ".$1")

    return prop.split('.').reduce(function (prev: any, curr: any) {
      return prev ? prev[curr] : undefined
    }, obj || self)
  } // --- end of fn getProp() --- //


  public static setPropValue(obj: any, path: any, value: any) {
    var a = path.split('.')
    var o = obj
    while (a.length - 1) {
      var n = a.shift()
      if (!(n in o)) o[n] = {}
      o = o[n]
    }
    o[a[0]] = value
  }

  public static getPropValue(obj: any, path: any) {
    path = path.replace(/\[(\w+)\]/g, '.$1')
    path = path.replace(/^\./, '')
    var a = path.split('.')
    var o = obj
    while (a.length) {
      var n = a.shift()
      if (!(n in o)) return
      o = o[n]
    }
    return o
  }

}
